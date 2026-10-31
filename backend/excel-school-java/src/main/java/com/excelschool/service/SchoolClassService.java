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

        var classe  =  foundClass.orElseThrow(() -> new SchoolClassNotFoundException(id));
        //2-mapper l'oject de la DB avec l'objet DTO
        var newClassDto = new SchoolClassDto(
                classe.getId(),
                classe.getName(),
                classe.getLevel()
        );
        //3 retourner le DTO
        return newClassDto;
    }
}
