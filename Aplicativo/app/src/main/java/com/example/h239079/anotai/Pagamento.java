package com.example.h239079.anotai;

import android.app.ProgressDialog;
import android.content.Intent;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

import com.example.h239079.anotai.model.Comanda;

import org.json.JSONObject;
import org.json.JSONStringer;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class Pagamento extends AppCompatActivity {

    String comandaSelecionada, idCliente, valorFinal;
    ListView listView;
    ArrayAdapter<Comanda> adapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_pagamento);

        Bundle bundle = getIntent().getExtras();
        comandaSelecionada = bundle.getString("comanda");
        idCliente = bundle.getString("idUsuario");
        valorFinal = bundle.getString("valorTotal");

        GetComandaTask task = new GetComandaTask();
        task.execute(comandaSelecionada);
    }

    public void finalizarComanda (View v)
    {
        CadastrarTask task = new CadastrarTask();
        task.execute(idCliente, comandaSelecionada, valorFinal);
        Intent it = new Intent (this, ComandaPaga.class);
        startActivity(it);
    }

    private class GetComandaTask extends AsyncTask<String, String, String> {

        private ProgressDialog progress;

        @Override
        protected void onPreExecute() {
            progress = ProgressDialog.show(Pagamento.this,
                    "Aguarde", "Buscando comanda...");
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

                    adapter = new ArrayAdapter<Comanda>(Pagamento.this, android.R.layout.simple_list_item_1, lista);

                    listView.setAdapter(adapter);
                }catch (Exception e){
                    e.printStackTrace();
                }
            }else{
                Toast.makeText(Pagamento.this, "Não foi possivel recuperar dados da comanda", Toast.LENGTH_LONG).show();
            }
        }
    }

    public class CadastrarTask extends AsyncTask<String, String, String> {

        ProgressDialog progressDialog;

        protected void onPreExecute() {
            progressDialog = ProgressDialog.show(Pagamento.this,
                    "Aguarde",
                    "Computando comanda no sistema...");
            super.onPreExecute();
        }

        protected String doInBackground(String... params) {
            URL url = null;
            try {
                url = new URL("http://10.0.2.2:65196/api/pedidofinalizado");
                HttpURLConnection connection = (HttpURLConnection) url.openConnection();
                connection.setRequestMethod("POST");
                connection.setRequestProperty("Content-Type", "application/json");

                JSONStringer json = new JSONStringer();
                json.object();
                json.key("DonoComandaId").value(params[0]);
                json.key("NumeroComanda").value(params[1]);
                json.key("ValorTotal").value(params[2]);
                json.endObject();

                OutputStreamWriter stream = new OutputStreamWriter(connection.getOutputStream());
                stream.write(json.toString());
                stream.close();

                String retorno = String.valueOf(connection.getResponseCode());

                return retorno;
            } catch (Exception e) {

            }
            return null;
        }

        @Override
        protected void onPostExecute(String s) {
            progressDialog.dismiss();
            if (s.equals("201")) {
                Toast.makeText(Pagamento.this, "Comanda paga e finalizada!", Toast.LENGTH_LONG).show();
            } else {
                Toast.makeText(Pagamento.this, "Erro ao pagar comanda", Toast.LENGTH_SHORT).show();
            }
        }
    }
}
