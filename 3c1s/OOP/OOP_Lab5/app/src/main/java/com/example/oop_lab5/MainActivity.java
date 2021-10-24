package com.example.oop_lab5;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.ContextMenu;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;

import static java.util.Collections.sort;

public class MainActivity extends AppCompatActivity {

    List<MyRecipes> recipes = new ArrayList<>();
    ArrayList<MyRecipes> states = new ArrayList();
    ListView countriesList;
    int position = -1;
    RecipesAdapter stateAdapter;
    RecipesComparator comparator = new RecipesComparator();
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        recipes = JSONHelper.importFromJSON(this);
        // начальная инициализация списка
        setInitialData();
        // получаем элемент ListView
        countriesList = findViewById(R.id.list);
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

        registerForContextMenu(countriesList);

    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {

        getMenuInflater().inflate(R.menu.main_menu, menu);
        return true;
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(menu, v, menuInfo);

        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.context_menu, menu);
    }
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        int id = item.getItemId();

        switch(id){
            case R.id.action_add:
                Intent intent = new Intent(this, NewRecipe.class);
                startActivity(intent);
                return true;
            case R.id.action_sort:
            {
                recipes.sort(comparator);
                stateAdapter.clear();
                stateAdapter.addAll(recipes);
                stateAdapter.notifyDataSetChanged();
            }
                return true;
            case R.id.action_search:
                Intent Sintent = new Intent(this, SearchRecipes.class);
                startActivity(Sintent);
                return true;
        }
        //headerView.setText(item.getTitle());
        return super.onOptionsItemSelected(item);
    }

    @Override
    public boolean onContextItemSelected(MenuItem item) {
        AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo) item.getMenuInfo();
        switch (item.getItemId()) {
            case R.id.edit:
                //editItem(info.position); // метод, выполняющий действие при редактировании пункта меню
            {
                Log.d("AAAAAA", recipes.get(info.position).nameRecipe);

                Intent intent = new Intent(this, NewRecipe.class);
                intent.putExtra("position", info.position);
                startActivity(intent);

            }
                return true;
            case R.id.delete: {
                position = info.position;
                showDialog();
            }
                return true;
            default:
                return super.onContextItemSelected(item);
        }
    }

    public void showDialog() {
        CustomDialogFragment dialog = new CustomDialogFragment();
        dialog.show(getSupportFragmentManager(), "custom");
    }

    private void setInitialData(){
        for(int i =0; i<recipes.size(); i++)
        states.add(recipes.get(i));
    }

    public void okClicked() {
         recipes.remove(position);

        stateAdapter.clear();
        stateAdapter.addAll(recipes);
        stateAdapter.notifyDataSetChanged();

        JSONHelper.exportToJSON(this, recipes);

    }



}