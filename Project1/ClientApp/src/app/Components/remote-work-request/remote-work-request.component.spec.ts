import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { RemoteWorkRequestComponent } from './remote-work-request.component';

let component: RemoteWorkRequestComponent;
let fixture: ComponentFixture<RemoteWorkRequestComponent>;

describe('RemoteWorkRequest component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ RemoteWorkRequestComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(RemoteWorkRequestComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});
