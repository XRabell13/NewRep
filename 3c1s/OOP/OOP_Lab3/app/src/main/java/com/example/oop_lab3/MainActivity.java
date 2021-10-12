package com.example.oop_lab3;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    EditText name, link, lastName, tel,  email;
    TextView pr;
    CheckBox chBox;

    Spinner spinner;

    User user = new User();



    //Объявляем используемые переменные:
    private ImageView imageView;
    private final int Pick_image = 1;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Log.d("Lab3", "MainActivity: onCreate()");

        name = findViewById(R.id.txName);
        lastName = findViewById(R.id.txLastName);
        spinner = findViewById(R.id.spinner);
        link = findViewById(R.id.txLink);
        tel = findViewById(R.id.txTel);
        email = findViewById(R.id.txEmail);
        chBox =  findViewById(R.id.checkBox); chBox.setChecked(false);
        pr = findViewById(R.id.textView13);
pr.setText("A1");

        Bundle arguments = getIntent().getExtras();

        if(arguments!=null){
            user = (User) arguments.getSerializable(User.class.getSimpleName());
            pr = findViewById(R.id.textView13);

            name.setText(user.name);
            lastName.setText(user.lastName);
         // spinner.setSelection(Integer.valueOf(user.spinner));
            link.setText(user.linkNet);
            tel.setText(user.telephone);
            email.setText(user.email);
            chBox.setActivated(user.checkJob);

            pr.setText(user.toString());
        }
        /*   if(arguments!=null){
            Log.d("Lab3", "ONCREATE after back1");
            lastUser = (User) arguments.getSerializable(User.class.getSimpleName());
            Log.d("Lab3", "ONCREATE after back2");

         name.setText(lastUser.name);
            lastName.setText(lastUser.lastName);
            spinner.setSelection(Integer.valueOf(lastUser.spinner));
            link.setText(lastUser.linkNet);
            tel.setText(lastUser.telephone);
            email.setText(lastUser.email);
            checkJob = lastUser.checkJob;
            pr.setText(lastUser.toString());

        }
        else pr.setText("A2");*/

    }


    public void nextSecondActivity(View view) {
        String txname = name.getText().toString();
        String txlastname = lastName.getText().toString();
        String txspinner = String.valueOf(spinner.getId());
        String txlink = link.getText().toString();
        String txtel = tel.getText().toString();
        String txemail = email.getText().toString();

        user.lastName = txlastname;
        user.name = txname;  user.spinner = txspinner; user.linkNet = txlink; user.telephone = txtel;
        user.email = txemail;
;

        Intent intent = new Intent(this, MainActivity2.class);

        intent.putExtra(User.class.getSimpleName(), user);
        startActivity(intent);

    }
    public void onCheckboxClicked(View view) {
        // Получаем флажок

        CheckBox check = (CheckBox) view;
        user.checkJob = check.isChecked();
        pr.setText(String.valueOf(user.checkJob));
      //  Toast.makeText(this, String.valueOf(user.checkJob), Toast.LENGTH_LONG);

    }

    public void ClickLink (View view){
        Uri address = Uri.parse("https://www.instagram.com/nastyalig/");
        Intent openlink = new Intent(Intent.ACTION_VIEW, address);
        startActivity(openlink);
    }

    public void ClickImg(View view){
        Intent intent = new Intent();
        intent.setAction(android.content.Intent.ACTION_VIEW);
        intent.setType("image/*");
        intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
        startActivity(intent);
    }


    protected void onStart() {
        super.onStart();
        Log.d("Lab3", "MainActivity: onStart()");

    }

    @Override
    protected void onResume() {
        super.onResume();
        Log.d("Lab3", "MainActivity: onResume()");
    }

    @Override
    protected void onPause() {
        super.onPause();
        Log.d("Lab3", "MainActivity: onPause()");
    }

    @Override
    protected void onStop() {
        super.onStop();
        Log.d("Lab3", "MainActivity: onStop()");
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        Log.d("Lab3", "MainActivity: onDestroy()");
    }



}