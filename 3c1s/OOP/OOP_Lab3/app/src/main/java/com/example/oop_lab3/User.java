package com.example.oop_lab3;
import android.graphics.Bitmap;
import android.net.Uri;

import java.io.ByteArrayOutputStream;
import java.io.Serializable;

public class User  implements Serializable {

    public String name = "";
    public String lastName="";
    public String spinner="";
    public String nameEducation="", faculty="", beginStudy="", endStudy="";
    public String organization="", specialization="", beginJob="", endJob="";
    public String company="", post="", email="", telephone="", linkNet="";
public boolean checkJob = false;
public String uriImg;

    public User(String name, String lastName, String email, String telephone, String linkNet,
                String spinner, String nameEducation, String faculty,
                String specialization, String beginStudy, String endStudy,
                String company, String job, String beginJob, String endJob, String uriImg) {
        this.name = name;
        this.lastName = lastName;
        this.spinner = spinner;
        this.nameEducation = nameEducation;
        this.specialization = specialization;
        this.telephone = telephone;
        this.linkNet = linkNet;
        this.beginStudy = beginStudy;
        this.endStudy = endStudy;
        this.beginJob = beginJob;
        this.endJob = endJob;
        this.company = company;
        this.post = job;
        this.email = email;
        this.uriImg = uriImg;
        this.faculty = faculty;
    }

    public User()
    {

    }

    @Override
    public  String toString(){
        return "ФИО: " + name +" "+lastName +" Специальность: "+specialization+" "+ nameEducation+" "
        +faculty+" " +beginStudy+" "+ endStudy+" "
                +organization+" "+ specialization+" "+ beginJob+" "+ endJob+" "
        +company+" "+post+" "+email+" "+telephone+" "+linkNet;
    }
}
