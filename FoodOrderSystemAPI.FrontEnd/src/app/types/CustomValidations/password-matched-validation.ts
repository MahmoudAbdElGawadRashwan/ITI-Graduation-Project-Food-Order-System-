import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export const PasswordMatchedValidation: ValidatorFn = (
  control: AbstractControl
): ValidationErrors | null => {
  const password = control.get('CustomerPassword');
  const confirmPassword = control.get('CustomerConfirmPassword');

  if (password && confirmPassword && password.value !== confirmPassword.value) {
    return { confirmPasswordMismatch: true };
  }

  return null;
};
