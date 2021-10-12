package com.example.oop_lab3;

import androidx.appcompat.app.AppCompatActivity;

import android.app.DatePickerDialog;
import android.app.Dialog;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.DatePicker;
import android.widget.TextView;

import java.util.Calendar;

public class MainActivity3 extends AppCompatActivity {

    Calendar ci = Calendar.getInstance();
    int DIALOG_DATE = 1;
    TextView pr;
    int myYear = ci.get(Calendar.YEAR);
    int myMonth = ci.get(Calendar.MONTH);
    int myDay = ci.get(Calendar.DAY_OF_MONTH);
    int idTextDate;

    User user;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main3);

        Log.d("Lab3", "MainActivity3: onCreate()");

        Bundle arguments = getIntent().getExtras();

        if(arguments!=null){
            user = (User) arguments.getSerializable(User.class.getSimpleName());
            pr = findViewById(R.id.textView13);

            pr.setText(user.toString());
        }
    }

    public void onclick(View view) {
        switch(view.getId()) {
            case R.id.textView3: {
                idTextDate = R.id.textView3;
                showDialog(DIALOG_DATE);
                break;
            }
            case R.id.textView6: {
                idTextDate = R.id.textView6;
                showDialog(DIALOG_DATE);
            }
            break;
            default:
                throw new IllegalStateException("Unexpected value: " + view.getId());
        }
    }

    protected Dialog onCreateDialog(int id) {
        if (id == DIALOG_DATE) {
            DatePickerDialog tpd = new DatePickerDialog(this, myCallBack, myYear, myMonth, myDay);
            return tpd;
        }
        return super.onCreateDialog(id);
    }

    DatePickerDialog.OnDateSetListener myCallBack = new DatePickerDialog.OnDateSetListener() {

        public void onDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth) {
            TextView tx;

            if(idTextDate == R.id.textView3) {
                tx = (TextView) findViewById(R.id.textView3);
            }
            else
            {
                tx = (TextView) findViewById(R.id.textView6);
            }
            tx.setText(" " + year + "/" + monthOfYear + "/" + dayOfMonth);
        }
    };

    public void backSecondActivity(View view) {
        Intent intent = new Intent(this, MainActivity2.class);
        intent.putExtra(User.class.getSimpleName(), user);
        startActivity(intent);
    }
    public void nextFinallyActivity(View view) {
        TextView organization = (TextView) findViewById(R.id.txJob);
        TextView post = (TextView) findViewById(R.id.txFaculty);

        TextView bjob = (TextView) findViewById(R.id.textView3);
        TextView ejob = (TextView) findViewById(R.id.textView6);


        user.organization = organization.getText().toString();
        user.post = post.getText().toString();
        user.beginJob = bjob.getText().toString();
        user.endJob = ejob.getText().toString();

        Intent intent = new Intent(this, MainActivity4.class);
        intent.putExtra(User.class.getSimpleName(), user);

        startActivity(intent);
    }


}