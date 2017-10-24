package com.example.h239079.anotai.model;

/**
 * Created by aleite on 24/10/2017.
 */

public class Comanda {
    private int id;
    private String donoComandaId;
    private String bebida;
    private String alimento;
    private String sobremesa;

    public Comanda(int id, String donoComandaId, String bebida, String alimento, String sobremesa) {
        this.id = id;
        this.donoComandaId = donoComandaId;
        this.bebida = bebida;
        this.alimento = alimento;
        this.sobremesa = sobremesa;
    }

    @Override
    public String toString() {
        return "Bebida: " + bebida + "\nAlimento: " +
                alimento + "\nSobremesa: " + sobremesa;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getDonoComandaId() {
        return donoComandaId;
    }

    public void setDonoComandaId(String donoComandaId) {
        this.donoComandaId = donoComandaId;
    }

    public String getBebida() {
        return bebida;
    }

    public void setBebida(String bebida) {
        this.bebida = bebida;
    }

    public String getAlimento() {
        return alimento;
    }

    public void setAlimento(String alimento) {
        this.alimento = alimento;
    }

    public String getSobremesa() {
        return sobremesa;
    }

    public void setSobremesa(String sobremesa) {
        this.sobremesa = sobremesa;
    }
}
