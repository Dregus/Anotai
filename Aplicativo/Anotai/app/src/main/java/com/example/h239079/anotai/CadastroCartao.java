package com.example.h239079.anotai;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.Button;
import android.widget.EditText;

public class CadastroCartao extends AppCompatActivity {

    private EditText edtNumeroCartao, edtValidade, edtCvv, edtTelefone;
    private Button btnCadastrarCartao;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cadastro_cartao);

        edtNumeroCartao = (EditText) findViewById(R.id.edtNumeroCartao);
        edtValidade = (EditText) findViewById(R.id.edtValidade);
        edtCvv = (EditText) findViewById(R.id.edtCvv);
        edtTelefone = (EditText) findViewById(R.id.edtTelefone);
        btnCadastrarCartao = (Button) findViewById(R.id.btnCadastrarCartao);
    }
}
