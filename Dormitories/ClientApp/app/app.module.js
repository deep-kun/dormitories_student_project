var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RequestService } from '../shared/request.service';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { TestComponent } from './test/test';
import { HomeComponent } from './home/home.component';
//guards
import { LoggedInGuard } from '../shared/LoggedInGuard';
import { LoggedInGuardAdministrator } from '../shared/LoggedInGuardAdministrator';
import { LoggedInGuardStudent } from '../shared/LoggedInGuardStudent';
import { LoggedInGuardFacultyAdmin } from '../shared/LoggedInGuardFacultyAdmin';
import { LoggedInGuardDormitoryAdmin } from '../shared/LoggedInGuardDormitoryAdmin';
import { NotLoggedInGuard } from '../shared/NotLoggedInGuard';
//student-pages
import { StudentHomeComponent } from './student/studentHome/studentHome.component';
import { StudentInfoComponent } from './student/studentInfo/studentInfo.component';
//facultyAdmin-pages
import { FacultyAdminHomeComponent } from './facultyAdmin/facultyAdminHome/facultyAdminHome.component';
import { FacultyAdminInfoComponent } from './facultyAdmin/facultyAdminInfo/facultyAdminInfo.component';
import { GroupsForFacultyAdministratorComponent } from './facultyAdmin/groups/groups.component';
import { FacultiesForFacultyAdminComponent } from './facultyAdmin/faculties/faculties.component';
import { StudentCategoriesForFacultyAdministratorComponent } from './facultyAdmin/studentCategories/studentCategories.component';
import { DormitoriesForFacultyAdministratorComponent } from './facultyAdmin/dormitories/dormitories.component';
import { DormitoryDetailsForFacultyAdministratorComponent } from './facultyAdmin/dormitories/dormitoryDetails/dormitoryDetails.component';
import { FloorDetailsForFacultyAdministratorComponent } from './facultyAdmin/floors/floorDetails/floorDetails.component';
import { BlockDetailsForFacultyAdministratorComponent } from './facultyAdmin/blocks/blockDetails/blockDetails.component';
import { RoomDetailsForFacultyAdministratorComponent } from './facultyAdmin/rooms/roomDetails/roomDetails.component';
import { StudentsForFacultyAdministratorComponent } from './facultyAdmin/students/students.component';
//dormitoryAdmin-pages
import { DormitoryAdminHomeComponent } from './dormitoryAdmin/dormitoryAdminHome/dormitoryAdminHome.component';
import { DormitoryAdminInfoComponent } from './dormitoryAdmin/dormitoryAdminInfo/dormitoryAdminInfo.component';
import { MyDormitoryComponent } from './dormitoryAdmin/myDormitory/myDormitory.component';
import { FacultiesForDormitoryAdminComponent } from './dormitoryAdmin/faculties/faculties.component';
import { GroupsForDormitoryAdministratorComponent } from './dormitoryAdmin/groups/groups.component';
import { RoomDetailsForDormitoryAdministratorComponent } from './dormitoryAdmin/room/roomDetails/roomDetails.component';
import { FloorDetailsForDormitoryAdministratorComponent } from './dormitoryAdmin/floor/floorDetails/floorDetails.component';
import { BlockDetailsForDormitoryAdministratorComponent } from './dormitoryAdmin/block/blockDetails/blockDetails.component';
import { StudentCategoriesForDormitoryAdministratorComponent } from './dormitoryAdmin/studentCategories/studentCategories.component';
//Administrator-pages
import { AdministratorHomeComponent } from './administrator/administratorHome/administratorHome.component';
import { RegisterComponent } from './register/register.component';
import { AdministratorInfoComponent } from './administrator/administratorInfo/administratorInfo.component';
import { DormitoriesForAdministratorComponent } from './administrator/dormitories/dormitories.component';
import { DormitoryDetailsForAdministratorComponent } from './administrator/dormitories/dormitoryDetails/dormitoryDetails.component';
import { DormitoryAddForAdministratorComponent } from './administrator/dormitories/dormitoryAdd/dormitoryAdd.component';
import { StudentCategoriesForAdministratorComponent } from './administrator/studentCategories/studentCategories.component';
import { StudentCategoryAddForAdministratorComponent } from './administrator/studentCategories/studentCategoryAdd/studentCategoryAdd.component';
import { FacultiesForAdministratorComponent } from './administrator/faculties/faculties.component';
import { FacultyAddForAdministratorComponent } from './administrator/faculties/facultyAdd/facultyAdd.component';
import { BooksForAdministratorComponent } from './administrator/books/books.component';
import { AuthorsForAdministratorComponent } from './administrator/authors/authors.component';
import { AuthorAddForAdministratorComponent } from './administrator/authors/authorAdd/authorAdd.component';
import { GroupsForAdministratorComponent } from './administrator/groups/groups.component';
import { GroupAddForAdministratorComponent } from './administrator/groups/groupAdd/groupAdd.component';
import { StudentsForAdministratorComponent } from './administrator/students/students.component';
import { StudentAddForAdministratorComponent } from './administrator/students/studentAdd/studentAdd.component';
import { FloorAddForAdministratorComponent } from './administrator/floors/floorAdd/floorAdd.component';
import { FloorDetailsForAdministratorComponent } from './administrator/floors/floorDetails/floorDetails.component';
import { FloorVisualizationDormitory8ForAdministratorComponent } from './administrator/floors/floorVisualization/dormitory8/floorVisualization.component';
import { BlockAddForAdministratorComponent } from './administrator/blocks/blockAdd/blockAdd.component';
import { BlockDetailsForAdministratorComponent } from './administrator/blocks/blockDetails/blockDetails.component';
import { BlockVisualization2RoomsForAdministratorComponent } from './administrator/blocks/blockVisualization/dormitory8/2Rooms/blockVisualization2Rooms.component';
import { BlockVisualization3RoomsForAdministratorComponent } from './administrator/blocks/blockVisualization/dormitory8/3Rooms/blockVisualization3Rooms.component';
import { RoomAddForFloorAdministratorComponent } from './administrator/rooms/roomAddForFloor/roomAdd.component';
import { RoomAddForBlockAdministratorComponent } from './administrator/rooms/roomAddForBlock/roomAdd.component';
import { RoomDetailsForAdministratorComponent } from './administrator/rooms/roomDetails/roomDetails.component';
import { RoomSettlingComponentForAdministrator } from './administrator/rooms/roomSettling/roomSettling.component';
//
import { ChangePasswordComponent } from './user/changePassword/changePassword.component';
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        NgModule({
            declarations: [
                AppComponent, LoginComponent, TestComponent, HomeComponent, ChangePasswordComponent, RegisterComponent,
                //Student
                StudentHomeComponent, StudentInfoComponent,
                //Administrator
                AdministratorHomeComponent, AdministratorInfoComponent,
                DormitoriesForAdministratorComponent, DormitoryDetailsForAdministratorComponent, DormitoryAddForAdministratorComponent,
                StudentCategoriesForAdministratorComponent, StudentCategoryAddForAdministratorComponent,
                FacultiesForAdministratorComponent, FacultyAddForAdministratorComponent,
                GroupsForAdministratorComponent, GroupAddForAdministratorComponent,
                BooksForAdministratorComponent,
                AuthorsForAdministratorComponent, AuthorAddForAdministratorComponent,
                StudentAddForAdministratorComponent, StudentsForAdministratorComponent,
                FloorAddForAdministratorComponent, FloorDetailsForAdministratorComponent, FloorVisualizationDormitory8ForAdministratorComponent,
                BlockAddForAdministratorComponent, BlockDetailsForAdministratorComponent, BlockVisualization2RoomsForAdministratorComponent, BlockVisualization3RoomsForAdministratorComponent,
                RoomAddForFloorAdministratorComponent, RoomAddForBlockAdministratorComponent, RoomDetailsForAdministratorComponent, RoomSettlingComponentForAdministrator,
                //FacultyAdmin
                FacultyAdminHomeComponent, FacultyAdminInfoComponent,
                GroupsForFacultyAdministratorComponent,
                FacultiesForFacultyAdminComponent,
                StudentCategoriesForFacultyAdministratorComponent,
                DormitoryDetailsForFacultyAdministratorComponent, DormitoriesForFacultyAdministratorComponent,
                FloorDetailsForFacultyAdministratorComponent,
                BlockDetailsForFacultyAdministratorComponent,
                RoomDetailsForFacultyAdministratorComponent,
                StudentsForFacultyAdministratorComponent,
                //DormitoryAdmin
                DormitoryAdminHomeComponent, DormitoryAdminInfoComponent,
                MyDormitoryComponent,
                FacultiesForDormitoryAdminComponent,
                GroupsForDormitoryAdministratorComponent,
                StudentCategoriesForDormitoryAdministratorComponent,
                RoomDetailsForDormitoryAdministratorComponent,
                FloorDetailsForDormitoryAdministratorComponent,
                BlockDetailsForDormitoryAdministratorComponent
            ],
            bootstrap: [
                AppComponent
            ],
            providers: [
                RequestService,
                HttpClient,
                LoggedInGuard,
                NotLoggedInGuard,
                LoggedInGuardAdministrator,
                LoggedInGuardDormitoryAdmin,
                LoggedInGuardFacultyAdmin,
                LoggedInGuardStudent
            ],
            imports: [
                BrowserModule,
                FormsModule,
                HttpClientModule,
                RouterModule.forRoot([
                    { path: '', redirectTo: 'home', pathMatch: 'full' },
                    { path: 'home', component: HomeComponent, canActivate: [NotLoggedInGuard] },
                    {
                        path: 'administrator-home', component: AdministratorHomeComponent,
                        children: [
                            { path: '', redirectTo: 'info', pathMatch: 'full' },
                            { path: 'info', component: AdministratorInfoComponent, canActivate: [LoggedInGuardAdministrator] },
                            { path: 'home', component: AdministratorHomeComponent, canActivate: [LoggedInGuardAdministrator] },
                            { path: 'studentCategories', component: StudentCategoriesForAdministratorComponent, canActivate: [LoggedInGuardAdministrator] },
                            { path: 'studentCategoryAdd', component: StudentCategoryAddForAdministratorComponent, canActivate: [LoggedInGuardAdministrator] },
                            { path: 'faculties', component: FacultiesForAdministratorComponent, canActivate: [LoggedInGuardAdministrator] },
                            { path: 'facultyAdd', component: FacultyAddForAdministratorComponent, canActivate: [LoggedInGuardAdministrator] },
                            { path: 'students', component: StudentsForAdministratorComponent, canActivate: [LoggedInGuardAdministrator] },
                            { path: 'studentAdd', component: StudentAddForAdministratorComponent, canActivate: [LoggedInGuardAdministrator] },
                            { path: 'floorAdd/:dormitoryId', component: FloorAddForAdministratorComponent, canActivate: [LoggedInGuardAdministrator] },
                            { path: 'floorDetails/:id', component: FloorDetailsForAdministratorComponent, canActivate: [LoggedInGuardAdministrator] },
                            { path: 'floorVisualization-dormitory8/:id', component: FloorVisualizationDormitory8ForAdministratorComponent, canActivate: [LoggedInGuardAdministrator] },
                            { path: 'blockVisualization2Rooms-dormitory8/:id', component: BlockVisualization2RoomsForAdministratorComponent, canActivate: [LoggedInGuardAdministrator] },
                            { path: 'blockVisualization3Rooms-dormitory8/:id', component: BlockVisualization3RoomsForAdministratorComponent, canActivate: [LoggedInGuardAdministrator] },
                            { path: 'blockAdd/:floorId', component: BlockAddForAdministratorComponent, canActivate: [LoggedInGuardAdministrator] },
                            { path: 'blockAdd/:floorId', component: BlockAddForAdministratorComponent, canActivate: [LoggedInGuardAdministrator] },
                            { path: 'blockDetails/:id', component: BlockDetailsForAdministratorComponent, canActivate: [LoggedInGuardAdministrator] },
                            { path: 'authors', component: AuthorsForAdministratorComponent, canActivate: [LoggedInGuardAdministrator] },
                            { path: 'authorAdd', component: AuthorAddForAdministratorComponent, canActivate: [LoggedInGuardAdministrator] },
                            { path: 'books', component: BooksForAdministratorComponent, canActivate: [LoggedInGuardAdministrator] },
                            { path: 'groups', component: GroupsForAdministratorComponent, canActivate: [LoggedInGuardAdministrator] },
                            { path: 'groupAdd', component: GroupAddForAdministratorComponent, canActivate: [LoggedInGuardAdministrator] },
                            { path: 'roomAdd/floor/:floorId', component: RoomAddForFloorAdministratorComponent, canActivate: [LoggedInGuardAdministrator] },
                            { path: 'roomAdd/block/:blockId', component: RoomAddForBlockAdministratorComponent, canActivate: [LoggedInGuardAdministrator] },
                            { path: 'roomDetails/:id', component: RoomDetailsForAdministratorComponent, canActivate: [LoggedInGuardAdministrator] },
                            { path: 'roomSettling/:id', component: RoomSettlingComponentForAdministrator, canActivate: [LoggedInGuard] },
                            { path: 'dormitories', component: DormitoriesForAdministratorComponent, canActivate: [LoggedInGuardAdministrator] },
                            { path: 'dormitoryAdd', component: DormitoryAddForAdministratorComponent, canActivate: [LoggedInGuardAdministrator] },
                            { path: 'dormitoryDetails/:id', component: DormitoryDetailsForAdministratorComponent, canActivate: [LoggedInGuardAdministrator] },
                            { path: 'changePassword/:username', component: ChangePasswordComponent, canActivate: [LoggedInGuardAdministrator] },
                            { path: '**', redirectTo: '', pathMatch: 'full', canActivate: [LoggedInGuardAdministrator] }
                            //todo: add other components
                        ]
                    },
                    {
                        path: 'student-home', component: StudentHomeComponent,
                        children: [
                            { path: '', redirectTo: 'info', pathMatch: 'full' },
                            { path: 'info', component: StudentInfoComponent, canActivate: [LoggedInGuardStudent] },
                            { path: 'home', component: StudentHomeComponent, canActivate: [LoggedInGuardStudent] },
                            { path: '**', redirectTo: '', pathMatch: 'full', canActivate: [LoggedInGuardStudent] }
                            //todo: add other components
                        ]
                    },
                    {
                        path: 'dormitory-admin-home', component: DormitoryAdminHomeComponent,
                        children: [
                            { path: '', redirectTo: 'info', pathMatch: 'full' },
                            { path: 'info', component: DormitoryAdminInfoComponent, canActivate: [LoggedInGuardDormitoryAdmin] },
                            { path: 'home', component: DormitoryAdminHomeComponent, canActivate: [LoggedInGuardDormitoryAdmin] },
                            { path: 'dormitory', component: MyDormitoryComponent, canActivate: [LoggedInGuardDormitoryAdmin] },
                            { path: 'faculties', component: FacultiesForDormitoryAdminComponent, canActivate: [LoggedInGuardDormitoryAdmin] },
                            { path: 'groups', component: GroupsForDormitoryAdministratorComponent, canActivate: [LoggedInGuardDormitoryAdmin] },
                            { path: 'studentCategories', component: StudentCategoriesForDormitoryAdministratorComponent, canActivate: [LoggedInGuardDormitoryAdmin] },
                            { path: 'roomDetails/:id', component: RoomDetailsForDormitoryAdministratorComponent, canActivate: [LoggedInGuardDormitoryAdmin] },
                            { path: 'floorDetails/:id', component: FloorDetailsForDormitoryAdministratorComponent, canActivate: [LoggedInGuardDormitoryAdmin] },
                            { path: 'blockDetails/:id', component: BlockDetailsForDormitoryAdministratorComponent, canActivate: [LoggedInGuardDormitoryAdmin] },
                            { path: 'changePassword/:username', component: ChangePasswordComponent, canActivate: [LoggedInGuardDormitoryAdmin] },
                            { path: '**', redirectTo: '', pathMatch: 'full', canActivate: [LoggedInGuardDormitoryAdmin] }
                            //todo: add other components
                        ]
                    },
                    {
                        path: 'faculty-admin-home', component: FacultyAdminHomeComponent,
                        children: [
                            { path: '', redirectTo: 'info', pathMatch: 'full' },
                            { path: 'info', component: FacultyAdminInfoComponent, canActivate: [LoggedInGuardFacultyAdmin] },
                            { path: 'home', component: FacultyAdminHomeComponent, canActivate: [LoggedInGuardFacultyAdmin] },
                            { path: 'dormitories', component: DormitoriesForFacultyAdministratorComponent, canActivate: [LoggedInGuardFacultyAdmin] },
                            { path: 'dormitoryDetails/:id', component: DormitoryDetailsForFacultyAdministratorComponent, canActivate: [LoggedInGuardFacultyAdmin] },
                            { path: 'faculties', component: FacultiesForFacultyAdminComponent, canActivate: [LoggedInGuardFacultyAdmin] },
                            { path: 'groups', component: GroupsForFacultyAdministratorComponent, canActivate: [LoggedInGuardFacultyAdmin] },
                            { path: 'studentCategories', component: StudentCategoriesForFacultyAdministratorComponent, canActivate: [LoggedInGuardFacultyAdmin] },
                            { path: 'students', component: StudentsForFacultyAdministratorComponent, canActivate: [LoggedInGuardFacultyAdmin] },
                            { path: 'roomDetails/:id', component: RoomDetailsForFacultyAdministratorComponent, canActivate: [LoggedInGuardFacultyAdmin] },
                            { path: 'floorDetails/:id', component: FloorDetailsForFacultyAdministratorComponent, canActivate: [LoggedInGuardFacultyAdmin] },
                            { path: 'blockDetails/:id', component: BlockDetailsForFacultyAdministratorComponent, canActivate: [LoggedInGuardFacultyAdmin] },
                            { path: 'changePassword/:username', component: ChangePasswordComponent, canActivate: [LoggedInGuardFacultyAdmin] },
                            { path: '**', redirectTo: '', pathMatch: 'full', canActivate: [LoggedInGuardFacultyAdmin] }
                            //todo: add other components
                        ]
                    },
                    { path: 'login', component: LoginComponent, canActivate: [NotLoggedInGuard] },
                    { path: 'register', component: RegisterComponent, canActivate: [NotLoggedInGuard] },
                    { path: '**', redirectTo: '', pathMatch: 'full' }
                ], { useHash: true })
            ]
        })
    ], AppModule);
    return AppModule;
}());
export { AppModule };
//# sourceMappingURL=app.module.js.map