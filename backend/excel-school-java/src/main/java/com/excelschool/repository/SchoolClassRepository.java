package com.excelschool.repository;

import com.excelschool.model.SchoolClass;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;


public interface SchoolClassRepository extends JpaRepository<SchoolClass, Integer> {
}
