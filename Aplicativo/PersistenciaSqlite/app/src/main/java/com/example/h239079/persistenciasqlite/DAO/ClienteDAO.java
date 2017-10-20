package com.example.h239079.persistenciasqlite.DAO;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.support.annotation.NonNull;

import com.example.h239079.persistenciasqlite.Model.Cliente;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by H239079 on 10-Oct-17.
 */

public class ClienteDAO extends SQLiteOpenHelper {

    private static final String BANCO = "clientes";
    private static final int VERSAO = 1;


    public ClienteDAO(Context context) {
        super(context, BANCO, null, VERSAO);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
                String sql ="CREATE TABLE TB_CLIENTE (CODIGO INTEGER " +
                        "PRIMARY KEY AUTOINCREMENT, NOME TEXT, EMAIL TEXT, " +
                        "IDADE INTEGER)";
        db.execSQL(sql);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        String sql = "DROP TABLE IF EXISTS TB_CLIENTE";
        db.execSQL(sql);
        onCreate(db);

    }

    public List<Cliente> listar(){
        Cursor cursor = getReadableDatabase().query("TB_CLIENTE",null,null,null,null,null,null);
        List<Cliente> lista = new ArrayList<>();
        while (cursor.moveToNext()){
            //Recuperar os valores das colunas
            int codigo = cursor.getInt(0);
            String nome = cursor.getString(1);
            String email = cursor.getString(2);
            int idade = cursor.getInt(3);
            Cliente cliente = new Cliente(codigo,nome,email,idade);
            lista.add(cliente);
        }
        return lista;
    }

    public void apagar(int codigo){
        getWritableDatabase().delete("TB_CLIENTE",
                "CODIGO = ?", new String[]{String.valueOf(codigo)});
    }

    public void adicionar(Cliente cliente){
        ContentValues valores = buildContentValues(cliente);
        getWritableDatabase().insert("TB_CLIENTE", null, valores);
    }

    @NonNull
    private ContentValues buildContentValues(Cliente cliente) {
        ContentValues valores = new ContentValues();
        valores.put("NOME",cliente.getNome());
        valores.put("EMAIL",cliente.getEmail());
        valores.put("IDADE",cliente.getIdade());
        return valores;
    }

    public void atualizar(Cliente cliente){
        ContentValues valores = buildContentValues(cliente);
        getWritableDatabase().update("TB_CLIENTE",valores,
                "CODIGO = ?", new String[]{
                        String.valueOf(cliente.getCodigo())});
    }
}
