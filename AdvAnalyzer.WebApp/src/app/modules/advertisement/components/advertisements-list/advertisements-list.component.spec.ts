import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdvertisementsListComponent } from './advertisements-list.component';

describe('AdvertisementsListComponent', () => {
  let component: AdvertisementsListComponent;
  let fixture: ComponentFixture<AdvertisementsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdvertisementsListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdvertisementsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
