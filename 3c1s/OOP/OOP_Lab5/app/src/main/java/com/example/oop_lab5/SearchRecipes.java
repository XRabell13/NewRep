package com.example.oop_lab5;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.EditText;
import android.widget.ListView;

import androidx.appcompat.app.AppCompatActivity;

import java.util.ArrayList;
import java.util.List;

public class SearchRecipes extends AppCompatActivity {
    List<MyRecipes> recipes = new ArrayList<>();

    ListView countriesList;
    RecipesAdapter stateAdapter;

    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.search_recipes);

        recipes = JSONHelper.importFromJSON(this);

        // получаем элемент ListView
        countriesList = findViewById(R.id.listSearch);
        // создаем адаптер
        stateAdapter = new RecipesAdapter(this, R.layout.list_item, recipes);
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
    List<MyRecipes> searchRecipes = new ArrayList<>();
    EditText searchWord = findViewById(R.id.txNameRecipeSearch);
    String str = searchWord.getText().toString();

    for(int i = 0; i<recipes.size(); i++)
    {
        if(recipes.get(i).nameRecipe.indexOf(str)!=-1)
            searchRecipes.add(recipes.get(i));
    }

    stateAdapter.clear();
    stateAdapter.addAll(searchRecipes);
    stateAdapter.notifyDataSetChanged();

}

}
