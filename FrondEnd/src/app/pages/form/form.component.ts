import { Component } from '@angular/core';
import {
  FormControl,
  FormGroup,
  NonNullableFormBuilder,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from '../../services/api.service';
import { PartsInterface } from '../../interfaces/parts.interface';

@Component({
  selector: 'app-form',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './form.component.html',
  styleUrl: './form.component.scss',
})
export class FormComponent {
  protected registerPart: FormGroup<{
    partsName: FormControl<string>;
    machineName: FormControl<string>;
    quantity: FormControl<number>;
    price: FormControl<number>;
  }>;

  constructor(
    private router: Router,
    private api: ApiService,
    private route: ActivatedRoute, // verificar se tem id ou não
    private formBuilder: NonNullableFormBuilder
  ) {
    // adicionar resto das valdidações
    this.registerPart = this.formBuilder.group({
      partsName: ['', [Validators.required]],
      machineName: ['', [Validators.required]],
      quantity: [0, [Validators.required, Validators.min(0)]],
      price: [0, [Validators.required, Validators.min(0.1)]],
    });
  }

  onSubmit(): void {
    if (this.registerPart.valid) {
      const value = this.registerPart.value as PartsInterface;
      this.api.addNewPart(value).subscribe({
        next: () => {
          this.router.navigate(['/list']);  
        },
        error: (err) => console.log(err),
      });
    }
  }

  onCancel(): void {
    this.registerPart.reset();
    this.router.navigate(['list']) 
  }
}
