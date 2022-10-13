import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MantEmpleadoListaComponent } from './mant-empleado-lista.component';

describe('MantEmpleadoListaComponent', () => {
  let component: MantEmpleadoListaComponent;
  let fixture: ComponentFixture<MantEmpleadoListaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MantEmpleadoListaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MantEmpleadoListaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
