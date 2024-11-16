import { Component, signal } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { PartsInterface } from '../../interfaces/parts.interface';

@Component({
  selector: 'app-list',
  standalone: true,
  imports: [],
  templateUrl: './list.component.html',
  styleUrl: './list.component.scss',
})
export class ListComponent {
  parts = signal<PartsInterface[]>([]);

  constructor(private api: ApiService) {
    this.getAllParts();
  }

  getAllParts(): void {
    this.api.getAllParts().subscribe({
      next: (data) => this.parts.set(data),
      error: (err) => console.log(err),
    });
  }

  deletePart(id: number): void {
    this.api.deletePart(id).subscribe({
      next: () => {
        const updatedParts = this.parts().filter((part) => part.id !== id);
        this.parts.set(updatedParts);
      },
      error: (err) => console.log(err),
    });
  }
}
