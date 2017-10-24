package com.example.h239079.anotai;

import android.app.ProgressDialog;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

import org.json.JSONException;
import org.json.JSONObject;
import org.json.JSONStringer;

import java.io.BufferedOutputStream;
import java.io.BufferedWriter;
import java.io.InputStream;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.URL;

public class RegistroActivity extends AppCompatActivity {

    private EditText txtNome, txtSobrenome, txtTelefone, txtEmail, txtSenha;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_registro);

        txtNome = (EditText) findViewById(R.id.txtNomeRegistro);
        txtSobrenome = (EditText) findViewById(R.id.txtSobrenomeRegistro);
        txtTelefone = (EditText) findViewById(R.id.txtTelefoneRegistro);
        txtEmail = (EditText) findViewById(R.id.txtEmailRegistro);
        txtSenha = (EditText) findViewById(R.id.txtSenhaRegistro);
    }

    public void Registrar(View v) {
        String tipoUsuario = "I";
        String nome = txtNome.getText().toString();
        String sobrenome = txtSobrenome.getText().toString();
        String telefone = txtTelefone.getText().toString();
        String cep = null;
        String endereco = null;
        String numeroCasa = null;
        String email = txtEmail.getText().toString();
        String senha = txtSenha.getText().toString();

        new CadastrarTask().execute(tipoUsuario, nome, sobrenome, telefone, cep, endereco, numeroCasa, email, senha);
    }

    public class CadastrarTask extends AsyncTask<String, String, String> {
        ProgressDialog progressDialog;

        protected void onPreExecute() {
            progressDialog = ProgressDialog.show(RegistroActivity.this,
                    "Aguarde",
                    "Cadastrando usuário...");
            super.onPreExecute();
        }

        protected String doInBackground(String... params) {
            URL url = null;
            try {
                url = new URL("http://10.0.2.2:65196/api/usuarios");
                HttpURLConnection connection = (HttpURLConnection) url.openConnection();
                connection.setRequestMethod("POST");
                connection.setRequestProperty("Content-Type", "application/json");

                JSONStringer json = new JSONStringer();
                json.object();
                json.key("TipoUsuario").value(params[0]);
                json.key("Nome").value(params[1]);
                json.key("Sobrenome").value(params[2]);
                json.key("Telefone").value(params[3]);
                json.key("Cep").value(params[4]);
                json.key("Endereco").value(params[5]);
                json.key("NumeroCasa").value(params[6]);
                json.key("Email").value(params[7]);
                json.key("Senha").value(params[8]);
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
                Toast.makeText(RegistroActivity.this, "Usuário cadastrado com sucesso. Volte uma tela para fazer login", Toast.LENGTH_LONG).show();
            } else {
                Toast.makeText(RegistroActivity.this, "Erro ao cadastrar usuário", Toast.LENGTH_SHORT).show();
            }
        }
    }
}
