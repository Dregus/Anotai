package com.example.h239079.anotai;

import android.app.AlertDialog;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;


public class MainActivity extends AppCompatActivity {

    private EditText edtUsuario, edtSenha;
    private Button btnEntrar, btnRegistro;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        edtUsuario = (EditText) findViewById(R.id.edtUsuario);
        edtSenha = (EditText) findViewById(R.id.edtSenha);
        btnEntrar = (Button) findViewById(R.id.btnEntrar);
        btnRegistro = (Button) findViewById(R.id.btnEntrar);

    }


    public void Login (View v)
    {
        if(edtUsuario.getText().toString().equals("usuario") && edtSenha.getText().toString().equals("u"))
        {
            Intent it = new Intent(MainActivity.this, GeradoraDeComanda.class);
            startActivity(it);
        }
        else if(edtUsuario.getText().toString().equals("garcom") && edtSenha.getText().toString().equals("g"))
        {
            Intent it = new Intent(MainActivity.this, Garcom.class);
            startActivity(it);
        }
        else
        {
            Toast.makeText(getApplicationContext(), "Login/Senha inválido!", Toast.LENGTH_SHORT).show();
        }

    }

    public void Registro (View v)
    {
        Intent it = new Intent (MainActivity.this, RegistroActivity.class);
        startActivity(it);
    }

    public void onBackPressed() {
        // metodo p o botao voltar nao funcionar
    }

}
