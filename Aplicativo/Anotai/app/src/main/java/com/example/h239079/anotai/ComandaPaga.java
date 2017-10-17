package com.example.h239079.anotai;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;

public class ComandaPaga extends AppCompatActivity {

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
}
