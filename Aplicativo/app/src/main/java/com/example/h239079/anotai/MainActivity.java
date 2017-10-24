package com.example.h239079.anotai;

import android.app.ProgressDialog;
import android.content.Intent;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.example.h239079.anotai.model.Usuario;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;


public class MainActivity extends AppCompatActivity {

    private EditText txtEmail, txtSenha;
    private Button btnEntrar, btnRegistro;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        txtEmail = (EditText) findViewById(R.id.txtEmailRegistro);
        txtSenha = (EditText) findViewById(R.id.txtSenhaRegistro);
    }

    public void Login(View v)
    {
        GetUsuariosTask task = new GetUsuariosTask();
        task.execute();
    }

    public void Registro (View v)
    {
        Intent it = new Intent (MainActivity.this, RegistroActivity.class);
        startActivity(it);
    }

    public void onBackPressed() {
        //travar botão back
    }

    private class GetUsuariosTask extends AsyncTask<Void, Void, String> {

        private ProgressDialog progress;

        @Override
        protected void onPreExecute() {
            progress = ProgressDialog.show(MainActivity.this,
                    "Aguarde", "Entrando...");
        }

        @Override
        protected String doInBackground(Void... v) {
            try {
                URL url = new URL(
                        "http://10.0.2.2:65196/api/usuarios");
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
                    JSONArray jsonArray = new JSONArray(s);

                    List<Usuario> lista = new ArrayList<>();

                    for (int i=0; i < jsonArray.length(); i++){
                        //Recupera cada item do vetor
                        JSONObject item = (JSONObject) jsonArray.get(i);

                        int id = item.getInt("UsuarioId");
                        String tipoUsuario = item.getString("TipoUsuario");
                        String nome = item.getString("Nome");
                        String sobrenome = item.getString("Sobrenome");
                        String telefone = item.getString("Telefone");
                        String cep = item.getString("Cep");
                        String endereco = item.getString("Endereco");
                        String numeroCasa = item.getString("NumeroCasa");
                        String email = item.getString("Email");
                        String senha = item.getString("Senha");
                        Usuario model = new Usuario(id, tipoUsuario, nome, sobrenome, telefone, cep, endereco, numeroCasa, email, senha);
                        lista.add(model);
                    }

                    for(int i=0; i < jsonArray.length(); i++){
                        String email = txtEmail.getText().toString();
                        String senha = txtSenha.getText().toString();

                        if(lista.get(i).getEmail().equals(email) && lista.get(i).getSenha().equals(senha)){
                            if(lista.get(i).getTipoUsuario().equals("G") || lista.get(i).getTipoUsuario().equals("A")) {
                                Intent it = new Intent(MainActivity.this, Garcom.class);
                                int idCliente = lista.get(i).getId();
                                String cliente = String.valueOf(idCliente);
                                it.putExtra("idCliente", cliente);
                                startActivity(it);
                            } else if(lista.get(i).getTipoUsuario().equals("I")) {
                                Intent it = new Intent(MainActivity.this, GeradoraDeComanda.class);
                                int idCliente = lista.get(i).getId();
                                String cliente = String.valueOf(idCliente);
                                it.putExtra("idCliente", cliente);
                                startActivity(it);
                            }
                        }
                    }
                }catch (Exception e){
                    e.printStackTrace();
                }
            }else{
                Toast.makeText(MainActivity.this, "Não foi possivel fazer o login", Toast.LENGTH_LONG).show();
            }
        }
    }

}
