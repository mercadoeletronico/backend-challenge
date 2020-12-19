package br.com.me.backendchallenge.validation;

import br.com.me.backendchallenge.enums.Status;

import javax.validation.ConstraintValidator;
import javax.validation.ConstraintValidatorContext;
import java.util.List;

public class StatusSubsetValidator implements ConstraintValidator<StatusSubset, Status> {
    private Status[] subset;

    @Override
    public void initialize(StatusSubset constraint) {
        this.subset = constraint.anyOf();
    }

    @Override
    public boolean isValid(Status value, ConstraintValidatorContext context) {
        return value == null || List.of(subset).contains(value);
    }
}