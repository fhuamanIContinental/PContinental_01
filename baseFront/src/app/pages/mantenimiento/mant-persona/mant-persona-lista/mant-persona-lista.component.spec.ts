import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MantPersonaListaComponent } from './mant-persona-lista.component';

describe('MantPersonaListaComponent', () => {
  let component: MantPersonaListaComponent;
  let fixture: ComponentFixture<MantPersonaListaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MantPersonaListaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MantPersonaListaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
