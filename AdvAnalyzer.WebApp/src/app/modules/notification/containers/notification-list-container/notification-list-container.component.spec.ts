import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NotificationListContainerComponent } from './notification-list-container.component';

describe('NotificationListContainerComponent', () => {
  let component: NotificationListContainerComponent;
  let fixture: ComponentFixture<NotificationListContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NotificationListContainerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NotificationListContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
