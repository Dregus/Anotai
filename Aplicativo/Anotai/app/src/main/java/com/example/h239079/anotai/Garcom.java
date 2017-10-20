package com.example.h239079.anotai;

import android.content.Intent;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Spinner;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

public class Garcom extends AppCompatActivity {

    private Spinner spnBebida, spnAlimento, spnSobremesa;
    private List <String> bebidas = new ArrayList<String>();
    private List <String> alimentos = new ArrayList<String>();
    private List <String> sobremesas = new ArrayList<String>();
    private String bebida, alimento, sobremesa;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_garcom);

        bebidas.add("-");
        bebidas.add("Cerveja Artesanal");
        bebidas.add("Cerveja Skol");
        bebidas.add("Cerveja Brahma");
        bebidas.add("Cerveja Heineken");

        alimentos.add("-");
        alimentos.add("Batata Frita");
        alimentos.add("Pizza");
        alimentos.add("Hamburguer");
        alimentos.add("Pastel");

        sobremesas.add("-");
        sobremesas.add("Petit Gateau");
        sobremesas.add("Mousse de Chocolate");
        sobremesas.add("Sorvete de Morango");
        sobremesas.add("Torta Holandesa");

        spnBebida = (Spinner) findViewById(R.id.spnBebida);
        spnAlimento = (Spinner) findViewById(R.id.spnAlimento);
        spnSobremesa = (Spinner) findViewById(R.id.spnSobremesa);

        ArrayAdapter<String> arrayAdapter = new ArrayAdapter<String>(this, android.R.layout.simple_spinner_dropdown_item, bebidas);
        ArrayAdapter<String> arrayAdapter1 = new ArrayAdapter<String>(this, android.R.layout.simple_spinner_dropdown_item, alimentos);
        ArrayAdapter<String> arrayAdapter2 = new ArrayAdapter<String>(this, android.R.layout.simple_spinner_dropdown_item, sobremesas);

        ArrayAdapter<String> spinnerArrayAdapter = arrayAdapter;
        ArrayAdapter<String> spinnerArrayAdapter1 = arrayAdapter1;
        ArrayAdapter<String> spinnerArrayAdapter2 = arrayAdapter2;

        spinnerArrayAdapter.setDropDownViewResource(android.R.layout.simple_spinner_item);
        spinnerArrayAdapter1.setDropDownViewResource(android.R.layout.simple_spinner_item);
        spinnerArrayAdapter2.setDropDownViewResource(android.R.layout.simple_spinner_item);


        spnBebida.setAdapter(spinnerArrayAdapter);
        spnAlimento.setAdapter(spinnerArrayAdapter1);
        spnSobremesa.setAdapter(spinnerArrayAdapter2);

        spnBebida.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                bebida = parent.getItemAtPosition(position).toString();

              /*   Toast.makeText(Garcom.this, "Bebida Selecionada: " + bebida, Toast.LENGTH_LONG).show();**/
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });

        spnAlimento.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                alimento = parent.getItemAtPosition(position).toString();

               /* Toast.makeText(Garcom.this, "Alimento Selecionado: " + alimento, Toast.LENGTH_LONG).show(); **/
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });

        spnSobremesa.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                sobremesa = parent.getItemAtPosition(position).toString();

               /* Toast.makeText(Garcom.this, "Sobremesa Selecionado: " + sobremesa, Toast.LENGTH_SHORT).show(); **/
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });
    }
    public void escolherMesa (View v)
    {
        Intent it = new Intent (this, PedidoFeito.class);
        startActivity(it);
    }

    public void onBackPressed() {
        Intent it = new Intent (this, MainActivity.class);
        startActivity(it);
    }
}
