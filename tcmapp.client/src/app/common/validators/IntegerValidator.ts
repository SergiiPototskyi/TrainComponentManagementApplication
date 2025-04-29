import { AbstractControl, ValidationErrors } from '@angular/forms';

export function IntegerValidator(control: AbstractControl): ValidationErrors | null {
  const value = control.value;
  if (value === null || value === '') return null;
  return Number.isInteger(+value) ? null : { notInteger: true };
}