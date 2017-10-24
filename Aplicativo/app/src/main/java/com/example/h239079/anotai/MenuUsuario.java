package com.example.h239079.anotai;

import android.app.ProgressDialog;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.view.LayoutInflater;
import android.view.View;
import android.support.design.widget.NavigationView;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.FrameLayout;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.example.h239079.anotai.model.Comanda;
import com.example.h239079.anotai.model.Usuario;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class MenuUsuario extends AppCompatActivity
        implements NavigationView.OnNavigationItemSelectedListener {

    String comandaSelecionada;
    ListView listView;
    ArrayAdapter<Comanda> adapter;
    TextView tvTotal;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.content_menu_usuario);

        Bundle bundle = getIntent().getExtras();
        comandaSelecionada = bundle.getString("comanda");
        listView = (ListView) findViewById(R.id.lvProdutos);
        tvTotal = (TextView) findViewById(R.id.txtValorTotal);

        GetComandaTask task = new GetComandaTask();
        task.execute(comandaSelecionada);

//      /*  LayoutInflater inflater = (LayoutInflater) this.getSystemService(LAYOUT_INFLATER_SERVICE);
//        View childLayout = inflater.inflate(R.layout.content_menu_usuario, (ViewGroup) findViewById(R.id.content_menu_usuario));
//        FrameLayout menuFrameLayout = (FrameLayout) findViewById(R.id.menuFrame);
//        menuFrameLayout.addView(childLayout); **/
//
//        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
//        ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
//                this, drawer, R.string.navigation_drawer_open, R.string.navigation_drawer_close);
//        drawer.setDrawerListener(toggle);
//        toggle.syncState();
//
//        NavigationView navigationView = (NavigationView) findViewById(R.id.nav_view);
//        navigationView.setNavigationItemSelectedListener(this);
    }

     @Override
     public void onBackPressed() {
        // metodo p o botao voltar nao funcionar
     }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_usuario, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    @SuppressWarnings("StatementWithEmptyBody")
    @Override
    public boolean onNavigationItemSelected(MenuItem item) {
        // Handle navigation view item clicks here.
        int id = item.getItemId();

        if (id == R.id.nav_cadastrar_comanda) {

            Intent it= new Intent(this, GeradoraDeComanda.class);
            startActivity(it);

        } else if (id == R.id.nav_pagamento) {

            Intent it= new Intent(this, CadastroCartao.class);
            startActivity(it);

        }
        else if (id == R.id.nav_sair) {

            Intent it= new Intent(this, MainActivity.class);
            startActivity(it);


        }

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        drawer.closeDrawer(GravityCompat.START);
        return true;


    }

    public void telaPagamento (View v)
    {
        Intent it = new Intent (this, Pagamento.class);
        startActivity(it);
    }

    public void atualizarComanda(View v) {
        GetComandaTask task = new GetComandaTask();
        task.execute(comandaSelecionada);
    }

    private class GetComandaTask extends AsyncTask<String, String, String> {

        private ProgressDialog progress;

        @Override
        protected void onPreExecute() {
            progress = ProgressDialog.show(MenuUsuario.this,
                    "Aguarde", "Entrando...");
        }

        @Override
        protected String doInBackground(String... params) {
            try {
                URL url = new URL(
                        "http://10.0.2.2:65196/api/comandas/" + params[0]);
                HttpURLConnection connection =
                        (HttpURLConnection) url.openConnection();
                connection.setRequestMethod("GET");
                connection.setRequestProperty("Accept","application/json");

                if (connection.getResponseCode() == 200){
                    BufferedReader reader = new BufferedReader
                            (new InputStreamReader(
                                    connection.getInputStream()));
                    StringBuilder builder = new StringBuilder();
                    String linha;
                    while ((linha = reader.readLine()) != null){
                        builder.append(linha);
                    }
                    connection.disconnect();

                    String retorno = builder.toString();
                    return retorno;
                } else {
                    return null;
                }
            }catch (Exception e){
                e.printStackTrace();
                return null;
            }
        }

        @Override
        protected void onPostExecute(String s) {
            // fecha a caixa de progresso
            progress.dismiss();

            if (s != null){
                try {
                    JSONObject json = new JSONObject(s);

                    List<Comanda> lista = new ArrayList<>();

                    int id = json.getInt("ComandaId");
                    String donoComandaId = json.getString("DonoComandaId");
                    String bebida = json.getString("Bebida");
                    String alimento = json.getString("Alimento");
                    String sobremesa = json.getString("Sobremesa");
                    Comanda model = new Comanda(id, donoComandaId, bebida, alimento, sobremesa);
                    lista.add(model);

                    adapter = new ArrayAdapter<Comanda>(MenuUsuario.this, android.R.layout.simple_list_item_1, lista);

                    listView.setAdapter(adapter);

                    Random r = new Random();
                    int value = r.nextInt(100);

                    tvTotal.setText(value);
                }catch (Exception e){
                    e.printStackTrace();
                }
            }else{
                Toast.makeText(MenuUsuario.this, "Não foi possivel recuperar dados da comanda", Toast.LENGTH_LONG).show();
            }
        }
    }

}
