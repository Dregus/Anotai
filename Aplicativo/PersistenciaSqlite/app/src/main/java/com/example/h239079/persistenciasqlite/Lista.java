package com.example.h239079.persistenciasqlite;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import com.example.h239079.persistenciasqlite.DAO.ClienteDAO;
import com.example.h239079.persistenciasqlite.Model.Cliente;

import java.util.List;

public class Lista extends AppCompatActivity {

    private ListView listView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_lista);

        listView = (ListView) findViewById(R.id.listView);

        ClienteDAO dao = new ClienteDAO(this);
        List<Cliente> clientes = dao.listar();

        ArrayAdapter<Cliente> adapter = new ArrayAdapter<Cliente>(this,
                android.R.layout.simple_list_item_1, clientes);

        listView.setAdapter(adapter);
    }

}
