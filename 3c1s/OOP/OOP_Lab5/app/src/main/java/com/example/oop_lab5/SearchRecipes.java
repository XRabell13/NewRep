package com.example.oop_lab5;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.EditText;
import android.widget.ListView;

import androidx.appcompat.app.AppCompatActivity;

import java.util.ArrayList;
import java.util.List;

public class SearchRecipes extends AppCompatActivity {
    List<MyRecipes> recipes = new ArrayList<>();
    ArrayList<MyRecipes> states = new ArrayList();
    ListView countriesList;
    RecipesAdapter stateAdapter;
    EditText searchWord;
    List<MyRecipes> searchRecipes = new ArrayList<>();

    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.search_recipes);

        searchWord =  findViewById(R.id.txNameRecipeSearch);

        recipes = JSONHelper.importFromJSON(this);
        setInitialData();
        // получаем элемент ListView
        countriesList = findViewById(R.id.listSearch);
        // создаем адаптер
        stateAdapter = new RecipesAdapter(this, R.layout.list_item, states);
        // устанавливаем адаптер
        countriesList.setAdapter(stateAdapter);
        // слушатель выбора в списке
        AdapterView.OnItemClickListener itemListener = new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View v, int position, long id) {

                Intent intent = new Intent(v.getContext(),RecipeInfo.class);
                intent.putExtra("position", position);
                startActivity(intent);
            }
        };
        countriesList.setOnItemClickListener(itemListener);
    }

public void searchRecipe(View v)
{
    String str = searchWord.getText().toString();
    for (int i = 0; i < recipes.size(); i++) {

        if (recipes.get(i).nameRecipe.contains(str)) {
            searchRecipes.add(recipes.get(i));
        }
    }

    stateAdapter.clear();
    stateAdapter.addAll(searchRecipes);
    stateAdapter.notifyDataSetChanged();
    searchRecipes.clear();
}
    private void setInitialData(){
        for(int i =0; i<recipes.size(); i++)
            states.add(recipes.get(i));
    }
}
