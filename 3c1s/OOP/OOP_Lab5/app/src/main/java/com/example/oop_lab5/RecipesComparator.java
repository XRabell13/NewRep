package com.example.oop_lab5;

import java.util.Comparator;
class RecipesComparator implements Comparator<MyRecipes>{
    public int compare(MyRecipes e1, MyRecipes e2){
        return e1.nameRecipe.compareTo(e2.nameRecipe);
    }

    public String toString(){
        return "StudentIdComparator";
    }
}