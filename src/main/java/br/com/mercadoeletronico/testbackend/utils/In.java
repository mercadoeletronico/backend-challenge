package br.com.mercadoeletronico.testbackend.utils;

import br.com.mercadoeletronico.testbackend.dto.Status;

import javax.validation.Constraint;
import javax.validation.ConstraintValidator;
import javax.validation.ConstraintValidatorContext;
import javax.validation.Payload;
import java.lang.annotation.Documented;
import java.lang.annotation.Retention;
import java.lang.annotation.Target;
import java.util.Arrays;

import static java.lang.annotation.ElementType.*;
import static java.lang.annotation.RetentionPolicy.RUNTIME;

@Target({ METHOD, FIELD, ANNOTATION_TYPE, CONSTRUCTOR, PARAMETER })
@Retention(RUNTIME)
@Documented
@Constraint(validatedBy = In.InConstraintValidator.class)
public @interface In
{
    String message() default "{YOURPACKAGE.In.message}";

    Class<?>[] groups() default { };

    Class<? extends Payload>[] payload() default {};

    Status[] values();

    class InConstraintValidator implements ConstraintValidator<In, Status> {

        private Object[] values;

        public final void initialize(final In annotation) {
            values = annotation.values();
        }

        public final boolean isValid(final Status value, final ConstraintValidatorContext context) {
            if (value == null){
                return true;
            }
            return Arrays.asList(values).contains(value); // check if value is in this.values
        }

    }
}

