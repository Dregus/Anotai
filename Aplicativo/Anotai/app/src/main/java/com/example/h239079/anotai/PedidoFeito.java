package com.example.h239079.anotai;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.RadioButton;

public class PedidoFeito extends AppCompatActivity {



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_pedido_feito);


    }


    public void voltarPedido(View v)
    {
        Intent it = new Intent (this, Garcom.class);
        startActivity(it);
    }
}
