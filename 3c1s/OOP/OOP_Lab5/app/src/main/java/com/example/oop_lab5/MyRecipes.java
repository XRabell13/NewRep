package com.example.oop_lab5;

public class MyRecipes {
// Список рецептов содержит название, категорию (суп, десерт и т.д.), ингредиенты, рецепт приготовления, фото, время.
//
    public String nameRecipe; // название
    public String category;
    public String ingredients;
    public String description;  // рецепт приготовления
    public String timeCook;
    public byte[] imageBytes = null;

    public MyRecipes(String nameRecipe, String category, String ingredients, String description, String timeCook, byte[] imageBytes)
    {
        this.nameRecipe = nameRecipe;
        this.category=category;
        this.ingredients = ingredients;
        this.description = description;
        this.timeCook = timeCook;
        this.imageBytes = imageBytes;
    }

public MyRecipes() {}

}
