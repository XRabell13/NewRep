package com.example.oop_lab3;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import java.util.List;

public class MainActivity4 extends AppCompatActivity {

    String file_name = "Laba.json";
    private ArrayAdapter<User> adapter;
    private EditText nameText, ageText;
    private List<User> users;
    ListView listView;
    User user;
    TextView pr;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main4);

        Bundle arguments = getIntent().getExtras();

        if(arguments!=null){
            user = (User) arguments.getSerializable(User.class.getSimpleName());
            pr = findViewById(R.id.textView00);//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            pr.setText(user.toString());
        }

    }
    public void backThirtyActivity(View view) {
        Intent intent = new Intent(this, MainActivity3.class);
        intent.putExtra(User.class.getSimpleName(), user);
        startActivity(intent);
    }
    public void saveData(View view) {

        boolean result = JSONHelper.exportToJSON(this, users);
        if(result){
            Toast.makeText(this, "Данные сохранены", Toast.LENGTH_LONG).show();
        }
        else{
            Toast.makeText(this, "Не удалось сохранить данные", Toast.LENGTH_LONG).show();
        }
        Toast.makeText(this,"save", Toast.LENGTH_LONG).show();
        Intent intent = new Intent(this, MainActivity5.class);
        startActivity(intent);

    }
}