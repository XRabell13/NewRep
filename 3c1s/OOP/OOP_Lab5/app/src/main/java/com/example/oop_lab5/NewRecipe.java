package com.example.oop_lab5;

import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.Bundle;
import android.util.ArraySet;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.io.RandomAccessFile;
import java.util.ArrayList;
import java.util.List;

public class NewRecipe extends AppCompatActivity {

    ImageView imageView;
    TextView nameRecipe;
    TextView timeCook;
    TextView category;
    TextView description;
    TextView ingredients;

    private final int Pick_image = 1;
    String fname="MyRecipes.json";

    private List<MyRecipes> recipes = new ArrayList<>();

    private MyRecipes recipe = new MyRecipes();

    int position = -1;

    byte[] byteIMG = null;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.new_recipe);

        Bundle arguments = getIntent().getExtras();


        recipes = JSONHelper.importFromJSON(this);

        nameRecipe = findViewById(R.id.txNameRecipe);
        timeCook = findViewById(R.id.txTimeCook);
        category = findViewById(R.id.txCategory);
        description = findViewById(R.id.txDescription);
        ingredients = findViewById(R.id.txIngredients);

        imageView = (ImageView)findViewById(R.id.photoIMG);
        //Связываемся с нашей кнопкой Button:
        Button PickImage = (Button) findViewById(R.id.butAddPhoto);
        //Настраиваем для нее обработчик нажатий OnClickListener:
        PickImage.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                //Вызываем стандартную галерею для выбора изображения с помощью Intent.ACTION_PICK:
                Intent photoPickerIntent = new Intent(Intent.ACTION_PICK);
                //Тип получаемых объектов - image:
                photoPickerIntent.setType("image/*");
                //Запускаем переход с ожиданием обратного результата в виде информации об изображении:
                startActivityForResult(photoPickerIntent, Pick_image);
            }
        });

        if (arguments != null) {
            position = arguments.getInt("position");

            nameRecipe.setText(recipes.get(position).nameRecipe);
            timeCook.setText(recipes.get(position).timeCook);
            category.setText(recipes.get(position).category);
            description.setText(recipes.get(position).description);
            ingredients.setText(recipes.get(position).ingredients);
            if(recipes.get(position).imageBytes!=null) {
                Bitmap selectedImage = BitmapFactory.decodeByteArray(recipes.get(position).imageBytes, 0, recipes.get(position).imageBytes.length);
                imageView.setImageBitmap(selectedImage);
            }

        }
    }

    //Обрабатываем результат выбора в галерее:
    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent imageReturnedIntent) {
        super.onActivityResult(requestCode, resultCode, imageReturnedIntent);

        switch(requestCode) {
            case Pick_image:
                if(resultCode == RESULT_OK){
                    try {

                        //Получаем URI изображения, преобразуем его в Bitmap
                        //объект и отображаем в элементе ImageView нашего интерфейса:
                        final Uri imageUri = imageReturnedIntent.getData();
                        final InputStream imageStream = getContentResolver().openInputStream(imageUri);
                        Bitmap selectedImage = BitmapFactory.decodeStream(imageStream);
                        imageView.setImageBitmap(selectedImage);
                        imageView.setRotation(90);

                        ByteArrayOutputStream bs = new ByteArrayOutputStream();
                        selectedImage.compress(Bitmap.CompressFormat.JPEG, 30, bs);

                        byteIMG = bs.toByteArray();
                        recipe.imageBytes = byteIMG;

                    } catch (FileNotFoundException e) {
                        e.printStackTrace();
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                }
        }}

    // метод для записи данных в файл
    public void saveData(View view) {

        recipe.nameRecipe = nameRecipe.getText().toString();
        recipe.timeCook = timeCook.getText().toString();
        recipe.description = description.getText().toString();
        recipe.category = category.getText().toString();
        recipe.ingredients = ingredients.getText().toString();

        boolean result;

        if (position == -1) {
            if (recipes.size() == 0) {
                List<MyRecipes> recip = new ArrayList<>();
                recip.add(recipe);
                result = JSONHelper.exportToJSON(this, recip);
            } else {
                recipes.add(recipe);
                result = JSONHelper.exportToJSON(this, recipes);
            }
            if (result) {
                Toast.makeText(this, "Данные сохранены", Toast.LENGTH_LONG).show();
            } else {
                Toast.makeText(this, "Не удалось сохранить данные", Toast.LENGTH_LONG).show();
            }
            Intent intent = new Intent(this, MainActivity.class);
            startActivity(intent);
        }
        else
        {
recipes.get(position).nameRecipe = nameRecipe.getText().toString();
recipes.get(position).timeCook = timeCook.getText().toString();
recipes.get(position).category = category.getText().toString();
recipes.get(position).description = description.getText().toString();
recipes.get(position).ingredients = ingredients.getText().toString();
recipes.get(position).imageBytes = byteIMG;
            result = JSONHelper.exportToJSON(this, recipes);
            if (result) {
                Toast.makeText(this, "Данные сохранены", Toast.LENGTH_LONG).show();
            } else {
                Toast.makeText(this, "Не удалось сохранить данные", Toast.LENGTH_LONG).show();
            }
            Intent intent = new Intent(this, MainActivity.class);
            startActivity(intent);
        }
    }
    private boolean ExistBase(String fname) {
        boolean rc = false;
        File f = new File(super.getFilesDir(), fname);
        if (rc = f.exists()) Log.d("Log_02", "Файл " + fname + " существуют");
        else Log.d("Log_02", "Файл " + fname + " не найден");

        return rc;
    }

}
