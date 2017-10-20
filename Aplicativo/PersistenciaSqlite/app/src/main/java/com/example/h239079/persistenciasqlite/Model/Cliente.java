package com.example.h239079.persistenciasqlite.Model;

/**
 * Created by H239079 on 10-Oct-17.
 */

public class Cliente {

    private int codigo;
    private String nome, email;
    private int idade;

    public Cliente(int codigo, String nome, String email, int idade) {
        this.codigo = codigo;
        this.nome = nome;
        this.email = email;
        this.idade = idade;
    }

    public Cliente() {

    }

    @Override
    public String toString() {
        return nome + "\n" + email + "\n" + idade;
    }

    public int getCodigo() {
        return codigo;
    }

    public void setCodigo(int codigo) {
        this.codigo = codigo;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public int getIdade() {
        return idade;
    }

    public void setIdade(int idade) {
        this.idade = idade;
    }
}
