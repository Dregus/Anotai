package com.example.h239079.persistenciasqlite;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

import com.example.h239079.persistenciasqlite.DAO.ClienteDAO;
import com.example.h239079.persistenciasqlite.Model.Cliente;

public class MainActivity extends AppCompatActivity {

    private EditText editNome, editIdade, editEmail;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        editNome = (EditText) findViewById(R.id.edit_nome);
        editEmail = (EditText) findViewById(R.id.edit_email);
        editIdade = (EditText) findViewById(R.id.edit_idade);

    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        //Adicionar o menu na tela
        getMenuInflater().inflate(R.menu.main_menu,menu);
        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        //Adicionar ação ao menu
        if (item.getItemId() == R.id.action_listar){
            //Navegar para a tela de listagem
            Intent intent = new Intent(this, Lista.class);
            startActivity(intent);
        }
        return super.onOptionsItemSelected(item);
    }

    public void cadastrar(View view){
        Cliente cliente = new Cliente();
        cliente.setNome(editNome.getText().toString());
        cliente.setEmail(editEmail.getText().toString());
        cliente.setIdade(Integer.parseInt(
                editIdade.getText().toString()));

        ClienteDAO dao = new ClienteDAO(this);
        dao.adicionar(cliente);

        Toast.makeText(this,"Cadastrado!",Toast.LENGTH_SHORT).show();
    }
}
