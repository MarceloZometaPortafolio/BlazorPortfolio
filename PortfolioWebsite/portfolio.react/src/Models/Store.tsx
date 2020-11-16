import Project from './Project';
import {Action, ActionCreator, Dispatch} from 'redux';

export interface AppState {
    readonly projectsList: Project[] | null;
}

interface GettingProjectsAction
    extends Action<'GettingProject'> {}

export interface GotProjectsAction
    extends Action<'GotProjects'> {
        projects: Project[];
    } 

export interface PostedNewProjectAction
    extends Action<'PostedNewProject'> {}

export interface UpdatedProjectAction
    extends Action<'UpdatedProject'> {}

export interface DeletedProjectAction
    extends Action<'DeletedProject'> {}

type AppStateActions = 
    | GettingProjectsAction
    | GotProjectsAction
    | PostedNewProjectAction
    | UpdatedProjectAction
    | DeletedProjectAction

export const getProjectsActionCreator = () => {
    return async (dispatch: Dispatch) => {
        const gettingProjectsAction : GettingProjectsAction = {
            type: 'GettingProject'
        }

        dispatch(gettingProjectsAction);

        // TODO - dispatch the GettingUnansweredQuestions action 
        // TODO - get the questions from server
        // TODO - dispatch the GotUnansweredQuestions action 
    };
    };