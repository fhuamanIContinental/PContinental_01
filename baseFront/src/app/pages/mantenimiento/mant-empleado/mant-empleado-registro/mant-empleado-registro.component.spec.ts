import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MantEmpleadoRegistroComponent } from './mant-empleado-registro.component';

describe('MantEmpleadoRegistroComponent', () => {
  let component: MantEmpleadoRegistroComponent;
  let fixture: ComponentFixture<MantEmpleadoRegistroComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MantEmpleadoRegistroComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MantEmpleadoRegistroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
