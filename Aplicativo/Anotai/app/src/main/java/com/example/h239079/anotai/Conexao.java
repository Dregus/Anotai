package com.example.h239079.anotai;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

/**
 * Created by H239079 on 16-Oct-17.
 */

public class Conexao {

        private static Connection connection;
        private static String url = "jdbc:oracle:thin:@192.168.60.15:1521:ORCL";
        private static String usuario = "OPS$RM73946";
        private static String senha = "240497";




        public static Connection getConnection() {
            if (connection == null) {
                try {
                    Class.forName("oracle.jdbc.driver.OracleDriver");
                    connection = DriverManager.getConnection(url, usuario, senha);
                }
                catch(ClassNotFoundException e) {}
                catch(SQLException e) {}
            }
            return connection;
        }
    }

