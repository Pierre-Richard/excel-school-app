package com.excelschool.service;

import com.excelschool.dto.SchoolClassDto;
import com.excelschool.exception.SchoolClassNotFoundException;
import com.excelschool.model.SchoolClass;
import com.excelschool.repository.SchoolClassRepository;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;

import java.util.Optional;

import static org.assertj.core.api.Assertions.assertThat;
import static org.junit.jupiter.api.Assertions.assertThrows;
import static org.mockito.Mockito.when;

@ExtendWith(MockitoExtension.class) // Active Mockito avec JUnit 5
public class SchoolClassServiceTest {

    @Mock
    SchoolClassRepository schoolClassRepository; // le faux


    @InjectMocks
    SchoolClassService service;            // le vrai, construit avec le faux

    @Test
    void getById_whenClassIdDoesNotExist_throwSchoolClassNotFoundException(){
        //Étant donné (Arrange) — le faux repository rend le carton vide
        int id = 999;
        when(schoolClassRepository.findById(id)).thenReturn(Optional.empty());
        //Quand (Act) getById, avec l'id
        // Alors : je verifie qu'il a bien que  SchoolClassNotFoundException a été lancé
        assertThrows(SchoolClassNotFoundException.class, () -> service.getById(id));
    }

    @Test
    void  getById_whenClassIdExists_ReturnSchoolClassDto(){
        // Étant donné : je PROGRAMME le faux (SchoolClassRepository) :
        //               pour l'id __3_ (Integer), il rend un carton ( Optional<SchoolClass>   ) PLEIN,
        //               qui contient une  classe (SchoolClass) avec : nom = "_excel___", niveau = "___3eme_
        Integer id = 3;
        String name = "excel";
        String level = "3éme";
        SchoolClass schoolClass = new SchoolClass();

        schoolClass.setId(id);
        schoolClass.setName(name);
        schoolClass.setLevel(level);
        when(schoolClassRepository.findById(id)).thenReturn(Optional.of(schoolClass));

        // Quand : service.getById(3) )___ (possédée par le SchoolClassService ) avec l'id ___3_ (__Integer__);
        SchoolClassDto foundClass = service.getById(id);

        // Alors : je VÉRIFIE que le result (__SchoolClassDto____) rendu contient :
        //         id = __3__, nom = "__excel__", niveau = "__3eme__"
        SchoolClassDto newSchoolClassDto = new SchoolClassDto(
                schoolClass.getId(),
                schoolClass.getName(),
                schoolClass.getLevel()
        );
        assertThat(foundClass).isEqualTo(newSchoolClassDto);
    }

}
