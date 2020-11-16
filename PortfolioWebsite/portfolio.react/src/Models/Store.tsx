import Project from './Project';
import {getProjects} from './Project';
import {Action, ActionCreator, Dispatch} from 'redux';
import { ThunkAction } from 'redux-thunk';

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

export const getProjectsActionCreator : ActionCreator<
    ThunkAction<
        Promise<void>,
        Project[],
        [],
        GotProjectsAction>
    > = () => {
    return async (dispatch: Dispatch) => {
        const gettingProjectsAction : GettingProjectsAction = {
            type: 'GettingProject'
        }

        dispatch(gettingProjectsAction);

        const projectsList = await getProjects();

        const gotProjectsAction : GotProjectsAction = {
            projects,
            type: 'GotProjects'
        }

        dispatch(gotProjectsAction);

        // TODO - dispatch the GettingUnansweredQuestions action 
        // TODO - get the questions from server
        // TODO - dispatch the GotUnansweredQuestions action 
    };
    };