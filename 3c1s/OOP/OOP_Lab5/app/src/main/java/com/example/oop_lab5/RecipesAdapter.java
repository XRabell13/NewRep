package com.example.oop_lab5;

import android.content.Context;
import android.graphics.BitmapFactory;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.List;

public class RecipesAdapter extends ArrayAdapter<MyRecipes> {

    private LayoutInflater inflater;
    private int layout;
    private List<MyRecipes> AllRecipes;

    public RecipesAdapter(Context context, int resource, List<MyRecipes> states) {
        super(context, resource, states);
        this.AllRecipes = states;
        this.layout = resource;
        this.inflater = LayoutInflater.from(context);
    }
    public View getView(int position, View convertView, ViewGroup parent) {

        View view=inflater.inflate(this.layout, parent, false);

        ImageView photoFood = view.findViewById(R.id.photo);
        TextView nameView = view.findViewById(R.id.nameRecipes);
        TextView ingredients = view.findViewById(R.id.ingredients);
        TextView timeCook = view.findViewById(R.id.timeCook);

        MyRecipes recipe = AllRecipes.get(position);

        if(recipe.imageBytes != null)
        photoFood.setImageBitmap(BitmapFactory.decodeByteArray(recipe.imageBytes,0,recipe.imageBytes.length));
        photoFood.setRotation(90);
        ingredients.setText(recipe.ingredients);
        nameView.setText(recipe.nameRecipe);
        timeCook.setText(recipe.timeCook);

        return view;
    }

    public void setList(List<MyRecipes> recipes) {
        AllRecipes.clear();
        AllRecipes = recipes;
    }
}
