package com.excelschool.exception;

public class SchoolClassNotFoundException extends RuntimeException {
    public SchoolClassNotFoundException(Integer id){
        super("La classe avec l'id " + id + " n'existe pas");
    }
}
