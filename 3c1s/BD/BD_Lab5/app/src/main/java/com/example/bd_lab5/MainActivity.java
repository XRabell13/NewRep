package com.example.bd_lab5;

import androidx.annotation.Nullable;
import androidx.annotation.RequiresApi;
import androidx.annotation.RequiresPermission;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import java.io.EOFException;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.RandomAccessFile;
import java.util.ArrayList;
import java.util.Hashtable;
import java.util.List;

import android.content.Context;
import android.content.DialogInterface;
import android.os.Build;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    String fname = "LabNEW.txt";
    HashTable hashT = new HashTable();


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

 if (ExistBase(fname)) {
            openText();
        } else {
            ShowDialogCreateFile();
            openText();
        }

    }

    private void ShowDialogCreateFile() {
        AlertDialog.Builder b = new AlertDialog.Builder(this);
        b.setTitle("Создается файл " + fname).setPositiveButton("Да", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                Log.d("Log_02", "Создание файла " + fname);
            }
        });
        AlertDialog ad = b.create();
        ad.show();

        try {
            FileOutputStream fileOutputStream = openFileOutput(fname, Context.MODE_PRIVATE);
            fileOutputStream.close();

        } catch (Exception e) {
            Log.d("ShowDialogCreateFile(): ERROR: ", e.getStackTrace()+"");
        }

    }

    private boolean ExistBase(String fname) {
        boolean rc = false;
        File f = new File(super.getFilesDir(), fname);
        if (rc = f.exists()) Log.d("Log_02", "Файл " + fname + " существуют");
        else Log.d("Log_02", "Файл " + fname + " не найден");

        return rc;
    }

    // вывод всего файла в текствью
    private void openText() {
        TextView textOut = (TextView) findViewById(R.id.outTextView);
        ReadFileHash();
        textOut.setText(hashT.toString());
    }


    private void ReadFileHash() {
        try {
            ObjectInputStream ois = new ObjectInputStream(openFileInput(fname));
            hashT = (HashTable) ois.readObject();
            ois.close();
        } catch (Exception ex) {

            System.out.println(ex.getMessage());

        }

    }


    @RequiresApi(api = Build.VERSION_CODES.N)
    public void SaveOnclick(View v) {

        EditText key = (EditText) findViewById(R.id.editTextKey);
        EditText value = (EditText) findViewById(R.id.editTextValue);

        ReadFileHash();

        hashT.setItem(key.getText().toString(), value.getText().toString());

        try
        {
            FileOutputStream fileOutputStream = openFileOutput(fname, Context.MODE_PRIVATE);
            ObjectOutputStream oos = new ObjectOutputStream(fileOutputStream);
            oos.writeObject(hashT);
            //очистка и закрытие
            oos.flush();
            oos.close();
            fileOutputStream.flush();
            fileOutputStream.close();
        }
        catch(Exception ex){
            System.out.println(ex.getMessage());

        }

        openText();

    }

    public void GetValueOnclick(View v)
    {

        EditText textView = findViewById(R.id.editTextValueGet);
        EditText findKey = findViewById(R.id.editTextKeyGet);

        textView.setText(hashT.getItem(findKey.getText().toString()));

    }

}