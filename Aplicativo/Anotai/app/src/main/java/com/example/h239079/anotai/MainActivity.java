package com.example.h239079.anotai;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    private EditText usuario, senha;
    private Button btnEntrar, btnRegistro;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        usuario = (EditText) findViewById(R.id.edtUsuario);
        senha = (EditText) findViewById(R.id.edtSenha);
        btnEntrar = (Button) findViewById(R.id.btnEntrar);
        btnRegistro = (Button) findViewById(R.id.btnEntrar);

    }

    public void Login(View v)
    {
        if(usuario.getText().toString().equals("a") && senha.getText().toString().equals("a"))
        {
            Intent it = new Intent(MainActivity.this, MenuUsuario.class);
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
