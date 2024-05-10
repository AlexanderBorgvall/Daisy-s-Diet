import { ComponentFixture, TestBed } from '@angular/core/testing';
import { EditHoursregisteredComponent } from './edit-hoursregistered.component';

describe('EditHoursregisteredComponent', () => {
  let component: EditHoursregisteredComponent;
  let fixture: ComponentFixture<EditHoursregisteredComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditHoursregisteredComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EditHoursregisteredComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

