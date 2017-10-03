package com.example.h239079.anotai;

import android.app.AlertDialog;
import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class RegistroActivity extends AppCompatActivity {

    private Button btnRegistrar;
    private EditText edtNomeRegistro, edtSobrenome, edtEmailRegistro, edtCelularRegistro, edtSenha, edtNomeUsuario;

    SQLiteDatabase db;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_registro);

        btnRegistrar = (Button) findViewById(R.id.btnRegistrar);
        edtNomeRegistro = (EditText) findViewById(R.id.edtNomeRegistro);
        edtSobrenome = (EditText) findViewById(R.id.edtSobrenome);
        edtEmailRegistro = (EditText) findViewById(R.id.edtEmailRegistro);
        edtCelularRegistro = (EditText) findViewById(R.id.edtCelularRegistro);
        edtSenha = (EditText) findViewById(R.id.edtSenha);
        edtNomeUsuario = (EditText) findViewById(R.id.edtNomeUsuario);


        db=openOrCreateDatabase("AnotaiDB", Context.MODE_PRIVATE, null);
        db.execSQL("CREATE TABLE IF NOT EXISTS anotai (edtSenha VARCHAR, edtNomeUsuario VARCHAR );");

    }

    public void onClick(View view) {
        if (view == btnRegistrar) {
            if (edtNomeRegistro.getText().toString().trim().length() ==0 || edtSobrenome.getText().toString().trim().length() == 0 ||
                edtEmailRegistro.getText().toString().trim().length() ==0 || edtCelularRegistro.getText().toString().trim().length() ==0 ||
                    edtSenha.getText().toString().trim().length() ==0 ||
                    edtNomeUsuario.getText().toString().trim().length() ==0) {
                showMessage("Erro!", "Preencha todos os campos");
                return;
            }
            db.execSQL("INSERT INTO anotai VALUES('" + edtSenha.getText() + "','" + edtNomeUsuario.getText() + "');");
            showMessage("Cadastro", "Cadastro feito com sucesso!");
            clearText();
        }
    }

    public void showMessage(String title,String message)
    {
        AlertDialog.Builder builder=new AlertDialog.Builder(this);
        builder.setCancelable(true);
        builder.setTitle(title);
        builder.setMessage(message);
        builder.show();
    }

    public void clearText()
    {
        edtSenha.setText("");
        edtNomeRegistro.setText("");
        edtEmailRegistro.setText("");
        edtSobrenome.setText("");
        edtNomeUsuario.setText("");
        edtNomeRegistro.requestFocus();
    }


}
