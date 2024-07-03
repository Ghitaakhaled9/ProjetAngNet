import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Observable } from 'rxjs';
import { Contact } from '../models/contact.model';
import { AsyncPipe } from '@angular/common';
import {FormControl, FormGroup, FormsModule, ReactiveFormsModule} from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HttpClientModule, AsyncPipe, FormsModule, ReactiveFormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title(title: any) {
    throw new Error('Method not implemented.');
  }
  http = inject(HttpClient);
  contactsForm =new FormGroup({
    name: new FormControl<string> (''),
    email: new FormControl<string | null>(''),
    phone: new FormControl<string>(''),
    favorite : new FormControl<boolean>(false)
  })

  contact$ = this.getContacts();
  onFormSubmit(){
    const addContactRequest = {
      name: this.contactsForm.value.name,
      email: this.contactsForm.value.email,
      phone: this.contactsForm.value.phone,
      favorite: this.contactsForm.value.favorite
    }
    this.http.post('https://localhost:7012/api/Contact', addContactRequest).subscribe({
      next: (value) => {
        console.log(value);
        this.contact$ = this.getContacts();
        this.contactsForm.reset();
      }
    });
  }

  onDelete(id:string){
    this.http.delete(`https://localhost:7012/api/Contact/${id}`).subscribe({
      next: (value) => {
        alert('item deleted');
        this.contact$=this.getContacts();

      }
    })
  }

  private getContacts(): Observable<Contact[]>{
    return this.http.get<Contact[]>('https://localhost:7012/api/Contact');
  }
}


