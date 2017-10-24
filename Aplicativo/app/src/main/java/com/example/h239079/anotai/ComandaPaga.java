package com.example.h239079.anotai;

import android.app.ProgressDialog;
import android.content.Intent;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Toast;

import com.example.h239079.anotai.model.Comanda;

import org.json.JSONStringer;

import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.URL;

public class ComandaPaga extends AppCompatActivity {

    String comandaSelecionada, idCliente, valorFinal;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_comanda_paga);
    }

    public void voltarMenu (View v)
    {
        Intent it = new Intent (this, MenuUsuario.class);
        startActivity(it);
    }

    public void voltarMain (View v)
    {
        Intent it = new Intent (ComandaPaga.this, MainActivity.class);
        startActivity(it);
    }
}
