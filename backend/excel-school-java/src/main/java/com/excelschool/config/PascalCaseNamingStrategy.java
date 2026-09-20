package com.excelschool.config;

import org.hibernate.boot.model.naming.Identifier;
import org.hibernate.boot.model.naming.PhysicalNamingStrategyStandardImpl;
import org.hibernate.engine.jdbc.env.spi.JdbcEnvironment;

/**
 * Le schéma a été créé par EF Core : tables et colonnes sont en PascalCase, entre guillemets
 * ("Class"."Id"). Cette stratégie transforme les noms Java (camelCase) en PascalCase et force
 * les guillemets, pour que les entités correspondent au schéma existant sans @Table/@Column
 * partout.
 */
public class PascalCaseNamingStrategy extends PhysicalNamingStrategyStandardImpl {

    @Override
    public Identifier toPhysicalTableName(Identifier name, JdbcEnvironment context) {
        return toPascalCase(name);
    }

    @Override
    public Identifier toPhysicalColumnName(Identifier name, JdbcEnvironment context) {
        return toPascalCase(name);
    }

    private static Identifier toPascalCase(Identifier name) {
        if (name == null) {
            return null;
        }
        String text = name.getText();
        String pascal = Character.toUpperCase(text.charAt(0)) + text.substring(1);
        return Identifier.toIdentifier(pascal, true);
    }
}
