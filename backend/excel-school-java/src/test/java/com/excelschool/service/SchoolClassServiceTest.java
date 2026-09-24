package com.excelschool.service;

import com.excelschool.dto.SchoolClassDto;
import com.excelschool.exception.SchoolClassNotFoundException;
import com.excelschool.repository.SchoolClassRepository;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;

import java.util.Optional;

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

}
