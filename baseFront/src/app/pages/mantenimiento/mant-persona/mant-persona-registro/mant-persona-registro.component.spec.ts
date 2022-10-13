import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MantPersonaRegistroComponent } from './mant-persona-registro.component';

describe('MantPersonaRegistroComponent', () => {
  let component: MantPersonaRegistroComponent;
  let fixture: ComponentFixture<MantPersonaRegistroComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MantPersonaRegistroComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MantPersonaRegistroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
