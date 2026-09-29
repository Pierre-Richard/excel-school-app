package com.excelschool.service;

import com.excelschool.dto.SchoolClassDto;
import com.excelschool.exception.SchoolClassNotFoundException;
import com.excelschool.model.SchoolClass;
import com.excelschool.repository.SchoolClassRepository;
import org.springframework.stereotype.Service;

@Service
public class SchoolClassService {
    private final SchoolClassRepository repository;

    public SchoolClassService(SchoolClassRepository schoolClassRepository){
        this.repository = schoolClassRepository;
    }

    public SchoolClassDto getById(Integer id){
        //1-à partir du repository je recois le carton
        var foundClass = repository.findById(id);
        //2-est-ce que ce carton contient une class SI NON LANCER exception
        if(foundClass.isEmpty()){
            throw new SchoolClassNotFoundException(id);
        }
        //3- si oui ouvrir le carton
        var classe  = foundClass.get();

        //4-mapper l'oject de la DB avec l'objet DTO
        var newClassDto = new SchoolClassDto(
             classe.getId(),
                classe.getName(),
                classe.getLevel()
        );
        //5retourner le DTO
        return newClassDto;
    }
}
