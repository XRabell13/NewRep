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
import java.util.Date;


public class MainActivity2 extends AppCompatActivity {

    Calendar ci = Calendar.getInstance();
    int DIALOG_DATE = 1;
    TextView pr;
    int myYear = ci.get(Calendar.YEAR);
    int myMonth = ci.get(Calendar.MONTH);
    int myDay = ci.get(Calendar.DAY_OF_MONTH);
    int idTextDate;
    User user;
User lastUser;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main2);

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

    public void backFirstActivity(View view) {

        TextView education = (TextView) findViewById(R.id.txEducation);
        TextView faculty = (TextView) findViewById(R.id.txFaculty);
        TextView special = (TextView) findViewById(R.id.txSpeciality);
        TextView bstudy = (TextView) findViewById(R.id.textView3);
        TextView estudy = (TextView) findViewById(R.id.textView6);


        user.nameEducation = education.getText().toString();
        user.faculty = faculty.getText().toString();
        user.specialization = special.getText().toString();
        user.beginStudy = bstudy.getText().toString();
        user.endStudy = estudy.getText().toString();

        Intent intent = new Intent(this, MainActivity.class);
        intent.putExtra(User.class.getSimpleName(), user);
        startActivity(intent);
    }
    public void nextThirtyActivity(View view) {
        TextView education = (TextView) findViewById(R.id.txEducation);
        TextView faculty = (TextView) findViewById(R.id.txFaculty);
        TextView special = (TextView) findViewById(R.id.txSpeciality);
        TextView bstudy = (TextView) findViewById(R.id.textView3);
        TextView estudy = (TextView) findViewById(R.id.textView6);


        user.nameEducation = education.getText().toString();
        user.faculty = faculty.getText().toString();
        user.specialization = special.getText().toString();
        user.beginStudy = bstudy.getText().toString();
        user.endStudy = estudy.getText().toString();

        if(user.checkJob) {
            Intent intent = new Intent(this, MainActivity3.class);
            intent.putExtra(User.class.getSimpleName(), user);

            startActivity(intent);
        }
        else
        {
            Intent intent = new Intent(this, MainActivity4.class);
            intent.putExtra(User.class.getSimpleName(), user);
            startActivity(intent);

        }
    }

    protected void onStart() {
        super.onStart();
        Log.d("Lab3", "MainActivity2: onStart()");

    }

    @Override
    protected void onResume() {
        super.onResume();
        Log.d("Lab3", "MainActivity2: onResume()");
    }

    @Override
    protected void onPause() {
        super.onPause();
        Log.d("Lab3", "MainActivity2: onPause()");
    }

    @Override
    protected void onStop() {
        super.onStop();
        Log.d("Lab3", "MainActivity2: onStop()");
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        Log.d("Lab3", "MainActivity2: onDestroy()");
    }
}