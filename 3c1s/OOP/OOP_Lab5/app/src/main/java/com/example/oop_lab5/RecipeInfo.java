package com.example.oop_lab5;

import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.Bundle;
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
import java.util.ArrayList;
import java.util.List;

public class RecipeInfo  extends AppCompatActivity {

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
        setContentView(R.layout.recipe_info);

        Bundle arguments = getIntent().getExtras();


        recipes = JSONHelper.importFromJSON(this);

        nameRecipe = findViewById(R.id.txNameRecipe);
        timeCook = findViewById(R.id.txTimeCook);
        category = findViewById(R.id.txCategory);
        description = findViewById(R.id.txDescription);
        ingredients = findViewById(R.id.txIngredients);

        imageView = (ImageView)findViewById(R.id.photoIMG);

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



    // метод для записи данных в файл
    public void saveData(View view) {

        Intent intent = new Intent(this, MainActivity.class);
        intent.putExtra("position", position);
        startActivity(intent);
    }
    private boolean ExistBase(String fname) {
        boolean rc = false;
        File f = new File(super.getFilesDir(), fname);
        if (rc = f.exists()) Log.d("Log_02", "Файл " + fname + " существуют");
        else Log.d("Log_02", "Файл " + fname + " не найден");

        return rc;
    }

}
